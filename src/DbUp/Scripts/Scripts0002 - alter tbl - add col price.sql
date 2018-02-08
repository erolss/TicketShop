/** Add columns for ticket price and max seats in tbl TicketEventDates.
* Price is self explainatory
* MaxSeats could be used as some event dates might be exclusive or specials.
*	Otherwise we could sell an infinite number of tickets
*/

ALTER TABLE TicketEventDates 
	ADD
	TicketPrice INT NOT NULL,
	MaxSeats INT NOT NULL;