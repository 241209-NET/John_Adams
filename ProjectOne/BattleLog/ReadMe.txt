Text-Based Battler
Overview
Text-Based Battler is an ASP.NET Core application that allows users to engage in text-based battles between a player and various enemies. 
The application features a RESTful API for managing players, enemies, and battle logs, with data persistence to a SQL Server database.

Features
Create, update, and delete player and enemy characters.
Create, update, and delete the outcome of battles in a battle log.
Persist data to a SQL Server database.
Engage in battles between a player and an enemy.--Stretch Goal--

RESTful API for CRUD operations on players, enemies, and battles.

Technologies
-ASP.NET Core
-Entity Framework Core
-SQL Server
-Swagger
API Endpoints:
Players:
GET /api/players: Retrieve all players.
GET /api/players/{id}: Retrieve a specific player by ID.
POST /api/players: Create a new player.
PUT /api/players/{id}: Update an existing player.
DELETE /api/players/{id}: Delete a player.

Enemies:
GET /api/enemies: Retrieve all enemies.
GET /api/enemies/{id}: Retrieve a specific enemy by ID.
POST /api/enemies: Create a new enemy.
PUT /api/enemies/{id}: Update an existing enemy.
DELETE /api/enemies/{id}: Delete an enemy.

Battle Logs:
GET /api/battlelogs: Retrieve all battle logs.
GET /api/battlelogs/{id}: Retrieve a specific battle log by ID.
POST /api/battlelogs: Create a new battle log.
PUT /api/battlelogs/{id}: Update an existing battle log.
DELETE /api/battlelogs/{id}: Delete a battle log.

Interacting with the Application: You can interact with the application using tools like Postman or Swagger to send HTTP requests to the 
API endpoints.