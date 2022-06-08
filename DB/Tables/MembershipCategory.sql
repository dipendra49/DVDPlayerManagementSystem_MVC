CREATE TABLE MembershipCategory
(
MembershipCategoryNumber BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
MembershipCategoryDescription VARCHAR(250) NULL,
MembershipCategoryTotalLoans DECIMAL(18,2) NULL
)