 Shiko Course Details Provider

- Microservice för att hämta detaljerad information om en kurs i Shiko LMS
- Exponerar ett REST API med endpoint för att hämta kurs med tillhörande key points
- Datan lagras i SQL Server via Entity Framework Core med schema `coursedetails`
- Körs lokalt med connection string i appsettings.json och driftsätts i Azure
