
CREATE TABLE TicketEvents (
    TicketEventID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    EventName varchar(255),
	EventHtmlDescription VARCHAR(MAX)
	/* image */
);

CREATE TABLE Venues (
    VenueID int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
    VenueName varchar(255),
    Address varchar(255),
    City varchar(255),
	Country VARCHAR(255)
);


CREATE TABLE TicketEventDates (
    TicketEventDateID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	TicketEventID INT FOREIGN KEY REFERENCES TicketEvents(TicketEventID),
	VenueID INT FOREIGN KEY REFERENCES Venues(VenueID),
    EventStartDateTime DATETIME,
	Price FLOAT NOT NULL,
	MaxTickets INT NOT NULL
);



CREATE TABLE Tickets (
    TicketID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TicketEventDateID INT FOREIGN KEY REFERENCES TicketEventDates(TicketEventDateID)
);

CREATE TABLE TicketTransactions (
    TransactionID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    BuyerLastName varchar(255),
    BuyerFirstName varchar(255),
    BuyerAddress varchar(255),
    BuyerCity varchar(255),
	PaymentStatus varchar(255),
	PaymentReferenceId varchar(255),
	BuyerEmail VARCHAR(255) NOT NULL,
	BuyerUserId VARCHAR(255) NOT NULL
);

CREATE TABLE TicketsToTransactions (
    TicketID INT  NOT NULL   FOREIGN KEY REFERENCES Tickets(TicketID),
	TransactionID INT  NOT NULL FOREIGN KEY REFERENCES TicketTransactions(TransactionID),
	primary key (TicketID, TransactionID)
);

