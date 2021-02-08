import React, { Component } from "react";
import { withStyles } from "@material-ui/core/styles";
import {
  Route,
} from "react-router-dom";
import { Container } from 'reactstrap';
import AllProducts from "../pages/AllProducts";
import Product from "../pages/Product";
import CreateProduct from "../pages/CreateProduct";
import DeleteProduct from "../pages/DeleteProduct";
import AboutUs from "../pages/AboutUs";

import PrivacyPolicy from "../pages/PrivacyPolicy";


const styles = theme => ({
  toolbar: theme.mixins.toolbar,
  title: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.default,
    padding: theme.spacing(3),
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
  },
  fullWidth: {
    width: '100%',
  },
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  },
  table: {
    minWidth: 650,
    },

    formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
    },
    selectEmpty: {
        marginTop: theme.spacing(2),
    },
});

class MainContent extends Component {
 
  render() {
    return (
      <Container>
          <Route
            exact
            path="/CreateProduct"
            render={() => {
              return <CreateProduct/>;
            }}
          />
          <Route
            exact
            path="/CreateProduct/:id"
            render={() => {
              return <CreateProduct/>;
            }}
          />
          <Route
            exact
            path="/allproducts"
            render={() => {
              return <AllProducts/>;
            }}
          />
          <Route
            exact
            path="/products/:id/delete"
            render={() => {
              return <DeleteProduct/>;
            }}
          />
          <Route
            exact
            path="/products/:id"
            render={() => {
              return <Product/>;
            }}
          />
          <Route
            exact
            path="/privacypolicy"
            render={() => {
              return <PrivacyPolicy/>;
            }}
          />
          <Route
            exact
            path="/aboutus"
            render={() => {
              return <AboutUs/>;
            }}
          />
        </Container>
    )
  }
}

export default withStyles(styles, { withTheme: true })(MainContent);