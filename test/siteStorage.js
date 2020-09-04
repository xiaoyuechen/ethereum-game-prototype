const SiteStorage = artifacts.require("SiteStorage");

contract("SiteStorage", accounts => {
    it("Should deploy", () => {
        return SiteStorage.deployed()
            .then(instance => {
                return instance.getSiteCount();
            })
            .then(count => {
                assert.equal(count, 0);
            });
    });

    it("Should add site", () => {
        let siteStorage;
        return SiteStorage.deployed()
            .then(instance => {
                siteStorage = instance;
                siteStorage.addSite(0, 0, 1, 1);
            })
            .then(() => {
                return siteStorage.getSiteCount();
            })
            .then(count => {
                assert.equal(count, 1);
            })
            .then(() => {
                return siteStorage.getSiteSize(0);
            })
            .then(size => {
                const {0: sizeX, 1: sizeY} = size;
                assert.equal(sizeX, 1);
                assert.equal(sizeY, 1);
            })
            .then(() => {
                return siteStorage.getSiteName(0);
            })
            .then(name => {
                assert.equal(name, "");
            })
            .then(() => {
                return siteStorage.getSiteColor(0);
            })
            .then(color => {
                assert.equal(color.toNumber(), Math.pow(2, 32) - 1);
            });
    });

    it("Should add message", async () => {
        let siteStorage = await SiteStorage.deployed();
        await siteStorage.addSite(0, 0, 1, 1);
        let originalCount = await siteStorage.getSiteMessageCount(0);
        assert.equal(originalCount, 0);
        await siteStorage.addSiteMessage(0, "hello!");
        let newCount = await siteStorage.getSiteMessageCount(0);
        assert.equal(newCount, 1);
        let msg = await siteStorage.getSiteMessage(0, 0);
        assert.equal(msg, "hello!");
    });
});