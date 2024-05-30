import axios from 'axios';
import { getUserToken } from '../stores/auth';

const api = axios.create({

  baseURL: "/api",

  // Request timeout
  timeout: 60000,

  // Request headers
  headers: {
    'Content-Type': 'application/json',
    Authorization: `Bearer ${getUserToken()}`
  },
});

export default api;
