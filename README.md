# TodoApp API

- [Item API](#TodoApp-api)
  - [Create Item](#create-item)
    - [Create Item Request](#create-item-request)
    - [Create Item Response](#create-item-response)
  - [Get Item](#get-item)
    - [Get Item Request](#get-item-request)
    - [Get Item Response](#get-item-response)
  - [Get Items](#get-items)
    - [Get Items Request](#get-items-request)
    - [Get Items Response](#get-items-response)
  - [Update Item](#update-item)
    - [Update Item Request](#update-item-request)
    - [Update Item Response](#update-item-response)
  - [Delete Item](#delete-item)
    - [Delete Item Request](#delete-item-request)
    - [Delete Item Response](#delete-item-response)
- [Auth API](#Auth-api)
  - [Login](#login)
    - [Login Request](#login-request)
    - [Login Response](#login-response)
  - [Register](#register)
    - [Register Request](#register-request)
    - [Register Response](#register-response)

## Create Item

### Create Item Request

```js
POST /ItemsAPI
```

```json
{
  "title": "Buy groceries",
  "description": "Milk, eggs, bread, vegetables",
  "priority": 1,
  "status": 0,
}
```

### Create Item Response

```js
200 Ok
```

```json
{
  "result": {
    "id": "00000000-0000-0000-0000-000000000000",
     "title": "Buy groceries",
     "description": "Milk, eggs, bread, vegetables",
     "priority": 1,
     "status": 0,
     "created_at": "2023-08-05T10:00:00Z",
     "updated_at": "2023-08-05T10:30:00Z"
  },
  "isSuccess": true,
  "message": null
}
```

## Get Item

### Get Item Request

```js
GET /ItemsAPI/{{id}}
```

### Get Item Response

```js
200 Ok
```

```json
{
  "result":{
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "Buy groceries",
    "description": "Milk, eggs, bread, vegetables",
    "priority": 1,
    "status": 0,
    "created_at": "2023-08-05T10:00:00Z",
    "updated_at": "2023-08-05T10:30:00Z"
  },
    "isSuccess": true,
    "message": null
}
```

## Get Items

### Get Items Request

```js
GET /ItemsAPI
```

### Get Items Response

```js
200 Ok
```

```json
{
    "result": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "title": "Buy groceries",
            "description": "Milk, eggs, bread, vegetables",
            "priority": 1,
            "status": 0,
            "created_at": "2023-08-05T10:00:00Z",
            "updated_at": "2023-08-05T10:30:00Z"
        },
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "title": "Buy groceries",
            "description": "Milk, eggs, bread, vegetables",
            "priority": 1,
            "status": 0,
            "created_at": "2023-08-05T10:00:00Z",
            "updated_at": "2023-08-05T10:30:00Z"
        }
    ],
    "isSuccess": true,
    "message": null
}
```

## Update Item

### Update Item Request

```js
PUT /ItemsAPI/{{id}}
```

```json
{
    "title": "Buy more groceries",
    "description": "Milk, eggs, bread, vegetables and chicken",
    "priority": 1,
    "status": 0,
}
```

### Update Item Response

```js
200 Ok
```

```json
{
  "result":{
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "Buy more groceries",
    "description": "Milk, eggs, bread, vegetables and chicken",
    "priority": 1,
    "status": 0,
    "created_at": "2023-08-05T10:00:00Z",
    "updated_at": "2023-08-05T10:30:00Z"
  },
    "isSuccess": true,
    "message": null
}
```

## Delete Item

### Delete Item Request

```js
DELETE /ItemsAPI/{{id}}
```

### Delete Item Response

```js
200 Ok
```

```json
{
  "result": null,
  "isSuccess": true,
  "message": null
}
```

## Login

### Login Request

```js
POST /AuthAPI/login
```

```json
{
  "userName": "string@string.com",
  "password": "password"
}
```

### Login Response

```js
200 Ok
```

```json
{
    "result": {
        "user": {
            "id": "00000000-0000-0000-0000-000000000000",
            "email": "string@string.com",
            "name": "string",
            "phoneNumber": "string"
        },
        "token": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
    },
    "isSuccess": true,
    "message": null
}
```

## Register

### Register Request

```js
POST /AuthAPI/register
```

```json
{
  "email": "string",
  "name": "string",
  "phoneNumber": "string",
  "password": "string"
}
```

### Register Response

```js
200 Ok
```

```json
{
  "result": null,
  "isSuccess": true,
  "message": null
}
```