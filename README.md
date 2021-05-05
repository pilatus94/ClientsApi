# ClientsApi

Audit logs not implemented.

Works on: http://localhost:5000

Requests:
GET /clients

GET /clients/{id}

DELETE /clients/{id}

POST /clients 
Body: 
{
    "name": "Name",
    "age": 100,
    "description": "New user"
}

PUT /clients/{id}
Body:
{
    "name": "Name",
    "age": 100,
    "description": "New user"
}
