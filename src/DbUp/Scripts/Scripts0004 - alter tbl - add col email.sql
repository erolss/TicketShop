/**
* added column email & UserID
*/

ALTER TABLE TicketTransactions
	ADD
		BuyerEmail VARCHAR(255) NOT NULL,
		BuyerUserId VARCHAR(255) NOT NULL UNIQUE;