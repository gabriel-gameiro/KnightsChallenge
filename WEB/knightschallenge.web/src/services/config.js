import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://localhost:44370/',
    withCredentials: false,
    headers: {                  
          "Access-Control-Allow-Origin": "*",
          "Access-Control-Allow-Headers": "Authorization", 
          "Access-Control-Allow-Methods": "GET, POST, OPTIONS, PUT, PATCH, DELETE" ,
          "Content-Type": "application/json;charset=UTF-8"                   
      }
});