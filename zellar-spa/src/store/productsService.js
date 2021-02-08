import http from "./http-common"

const getProducts = () => {
  return http
    .createAxios()
    .get("/api/v1/products");
};
const getAllProducts = () => {
  return http
    .createAxios()
    .get("/api/v1/products/getall");
};

const getProduct = (id) => {
  return http
    .createAxios()
    .get(`/api/v1/products/${id}`);
};

const createProduct = (data) => {
  return http
    .createAxios()
    .post(`/api/v1/products`,data);
};


const deleteProduct = (id) => {
  return http
    .createAxios()
    .delete(`/api/v1/products/${id}`);
};

const editProduct = ( id, data) => {
  return http
    .createAxios()
    .patch(`/api/v1/products/${id}`,data);
};
export default {
  getProducts,
  getProduct,
  deleteProduct,
  createProduct,
  editProduct,
  getAllProducts
};