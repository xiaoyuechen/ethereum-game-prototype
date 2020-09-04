const SiteStorage = artifacts.require("SiteStorage");

module.exports = function (deployer) {
  deployer.deploy(SiteStorage);
};
