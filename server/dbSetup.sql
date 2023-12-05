-- Active: 1701567647327@@SG-midi-taurus-4990-7989-mysql-master.servers.mongodirector.com@3306@The-Neon-Tsunami
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS cults(
  id INT PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  coverImg VARCHAR(500) NOT NULL,
  memberCount INT DEFAULT 0,
  fee DOUBLE DEFAULT 0,
  invitationRequired BOOLEAN DEFAULT false,
  leaderId VARCHAR(255) NOT NULL,
  Foreign Key (leaderId) REFERENCES accounts(id)
) default charset utf8;

INSERT INTO cults
(name, description, coverImg, fee, invitationRequired, leaderId)
VALUES
("Pumpkin Spice Life", "All about that PSL life, Don't hate just cause your coffee taste like dirt?!", "https://images.unsplash.com/photo-1569383893830-b73dc4a03af0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80", 5, false, '6436ed2a177c4641f6e0c6ce');

DROP TABLE cults

CREATE TABLE IF NOT EXISTS cultMembers(
  id INT PRIMARY KEY AUTO_INCREMENT,
  cultId INT NOT NULL,
  accountId VARCHAR(255) NOT NULL,
  Foreign Key (cultId) REFERENCES cults(id),
  Foreign Key (accountId) REFERENCES accounts(id)
) default charset utf8;

DROP TABLE cultMembers