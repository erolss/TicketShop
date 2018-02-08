/**
* added column email
*/

ALTER TABLE TicketTransactions
	ADD
		BuyerEmail VARCHAR(255) NOT NULL;