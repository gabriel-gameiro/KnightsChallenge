import axios from 'axios'

// Service que retorna a conexao com o backend ja iniciada. Centralizando assim a configuracao.
export const http = axios.create({
    baseURL: 'http://127.0.0.1:8081/',
    withCredentials: false,
    headers: {                  
          "Access-Control-Allow-Origin": "*",
          "Access-Control-Allow-Headers": "Authorization", 
          "Access-Control-Allow-Methods": "GET, POST, OPTIONS, PUT, PATCH, DELETE" ,
          "Content-Type": "application/json;charset=UTF-8"                   
      }
});