CREATE TABLE CastMember
(
DVDNumber BIGINT FOREIGN KEY REFERENCES DVDTitle(DVDNumber),
ActorNumber BIGINT FOREIGN KEY REFERENCES Actor(ActorNumber)
)