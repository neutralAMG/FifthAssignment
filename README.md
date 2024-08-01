
Internet Banking Application
Overview
This Internet Banking Application is designed to provide a secure and efficient platform for managing user accounts, performing financial transactions, and handling various banking products. The application leverages ASP.NET Core Identity for user authentication and role management, ensuring secure access and operations.

Features
User Management: Utilizes ASP.NET Core Identity to handle user authentication and authorization. Supports various roles such as Admin and Client.
Admin Role: Manages users, roles, and products assignments.
Client Role: Manages personal financial products and performs transactions.
Product Management: Supports up to 3 different types of financial products. Users can view and manage their products, which may include:
Bank Accounts
Credit Cards
Loans

Transaction Handling: Allows users to perform up to 5 different types of transactions, including:
Loan Payments: Pay down existing loans.
Credit Card Payments: Manage and pay credit card balances.
Money Advances: Request and manage cash advances.
Transfers: Move funds between accounts.
Beneficiary Payments: Make payments to added beneficiaries

Technologies Used
ASP.NET Core: Framework for building the web application.
ASP.NET Core Identity: Manages user authentication and roles.
Entity Framework Core: ORM for data handling.
SQL Server: Database for storing user information and transaction data.
