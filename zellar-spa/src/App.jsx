import "./App.css";
import React from "react";
import { Component } from "react";
import Layout from "./components/Layout";

export default class App extends Component {
  static displayName = App.name;
  
  

  render() {
    return (
      <Layout />
    )
  };
}