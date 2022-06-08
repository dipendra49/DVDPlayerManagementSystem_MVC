CREATE TABLE DVDTitle
(
DVDNumber BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
ProducerNumber BIGINT FOREIGN KEY REFERENCES Producer(ProducerNumber),
CategoryNumber BIGINT FOREIGN KEY REFERENCES DVDCategory(CategoryNumber),
StudioNumber BIGINT FOREIGN KEY REFERENCES Studio(StudioNumber),
DateReleased DATETIME,
StandardCharge DECIMAL(10,2),
PenaltyCharge DECIMAL(10,2)
)