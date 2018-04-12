Models
	BudgetEntries
	TransactionEntries
	GoalEntries
	Categories
	AspNetUsers

Implementation
	Once an account has been created, a row will be inserted into the AspNetUsers table,
	and an id will be generated. This id acts as the primary key, and allows communication 
	to other data sets. Users can then navigate to different pages in the site. For budget entires, users 
	will fill out a form. This data is persistent and can be edited over time. Edits will
	apply inserts and updates to the BudgetEntries table. Similarly, users will be able to fill out
	a form to keep a log of their transaction entries. These transactions can't be edited, but can be
	appended with new data (insertions). Routine deletes will happen once a user has passed a given number 
	of transactions. Finally, users can add goals along with variables that help give an estimate on how long it 
	might take to pay off debt. When used together this forms the perfect combination of a budget calcuating, debt 
	churning, data collecting machine.

Relations
	Be sure to check out the pdf that has a diagram of the current relations.