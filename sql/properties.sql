CREATE TABLE `properties` (
  `Id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Address` varchar(45) NOT NULL,
  `AgencyCode` varchar(45) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Latitude` decimal(10,7) NOT NULL,
  `Longitude` decimal(10,7) NOT NULL,
  `Advertised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Advertised` (`Advertised`),
  KEY `Latitude_Longitude` (`Longitude`,`Latitude`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `properties`
  (`Address`, `AgencyCode`, `Name`, `Latitude`, `Longitude`)
VALUES
  ('31 Hereford Street, Glebe NSW', 'CRE', 'The Summit Apartments', -33.8787075, 151.1820893);
        
INSERT INTO `properties`
  (`Address`, `AgencyCode`, `Name`, `Latitude`, `Longitude`)
VALUES
  ('4 McDonald Street, Potts Point NSW', 'LRE', 'Luxurious Apartments', -33.8677394, 151.2229558);
        
INSERT INTO `properties`
  (`Address`, `AgencyCode`, `Name`, `Latitude`, `Longitude`)
VALUES
  ('32 Sir John Young Crescent, Sydney NSW', 'OTBRE', 'Super High Apartments, Sydney', -33.8707617, 151.2151041);