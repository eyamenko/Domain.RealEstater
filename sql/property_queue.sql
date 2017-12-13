CREATE TABLE `property_queue` (
  `Id` binary(16) NOT NULL,
  `Message` varchar(20000) NOT NULL,
  `Dequeued` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Dequeued` (`Dequeued`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;