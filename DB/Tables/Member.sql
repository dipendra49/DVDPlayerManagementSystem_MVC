CREATE TABLE Member
(
MemberNumber BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
MembershipCategoryNumber BIGINT FOREIGN KEY REFERENCES MembershipCategory(MembershipCategoryNumber),
MemberLastName VARCHAR(250),
MemberFirstName VARCHAR(250),
MemberAddress VARCHAR(250),
MemberDOB DATETIME,
)