import axios from "axios";

const createAxios = () => {
  return axios.create({
      baseURL: process.env.REACT_APP_ACCOUNTS_API
  })
};

export default {
  createAxios
};