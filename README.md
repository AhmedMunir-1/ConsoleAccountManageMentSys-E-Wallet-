                                                   Title 
                                      E-Wallet Console Application (C#)
                                              
Description : 

This project is a simple E-Wallet system built using C# Console Application
to practice Object-Oriented Programming (OOP) and Object-Oriented Design (OOD).


Features : 

• Create Wallet
• Deposit Money
• Withdraw Money
• Transfer Money
• Transaction History
• Change Password


Concepts Practiced :

• Encapsulation
• Abstraction
• Object Collaboration
• Basic OOD Design


Technologies :

 C#
.NET
Console Application                        

                                              ---------------------------------
                                                 OOD (Object-Oriented Design)  
                                              ----------------------------------

                                  *** Look at most IMP Diagrams inside Diagrams Img File ***

🧩 Main Classes

1. Wallet

Responsibility:
	•	Represents user account (E-Wallet)
	•	Handles operations (Deposit, Withdraw, Transfer)

Attributes:
	•	PhoneNumber
	•	NationalId
	•	Name
	•	Password
	•	Balance
	•	Transactions (List)

Methods:
	•	Deposit()
	•	Withdraw()
	•	Transfer()
	•	ChangePassword()
	•	GetBalance()
	•	ShowTransactions()
	•	ValidationData()

⸻

2. Transaction

Responsibility:
	•	Represents any financial operation

Attributes:
	•	Id
	•	SenderName
	•	ReceiverName
	•	Date
	•	Amount
	•	Type (Deposit, Withdraw, Transfer)
	•	Status (Success, Failed)

⸻

3. Enums

TransactionType
	•	Deposit
	•	Withdraw
	•	Transfer

TransactionStatus
	•	Success
	•	Failed
	•	Pending (optional improvement)

⸻

4. Program (Main)

Responsibility:
	•	Acts as UI / entry point
	•	Calls Wallet methods

⸻

🔷 2. Relationships (VERY IMPORTANT for OOD)
	•	Wallet ➝ Transaction
	•	Relationship: Composition
	•	Reason: Wallet owns transactions
	•	Wallet ➝ Wallet (Transfer)
	•	Relationship: Association
	•	One wallet interacts with another


                                         architecture diagram for a console-based E-Wallet system.
                                        -----------------------------------------------------------
                                        

Layers:
- Presentation Layer (Program.cs)
- Business Logic Layer (Wallet class)
- Data Layer (Transaction storage in memory)

Show interactions between layers.

Style:
- clean layered architecture
- minimal icons

*** Look at most IMP Diagrams inside Diagrams Img File ***
                                                         
                                              
