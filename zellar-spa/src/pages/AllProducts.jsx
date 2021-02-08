
import React from "react";
import { Typography } from '@material-ui/core';
import productsService from "../store/productsService";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";

class AllProducts extends React.Component {
  static displayName = AllProducts.name;

  constructor(props) {
    super(props);

    this.state = {
      products: []
    }

  }
  componentDidMount() {
     
        productsService
          .getAllProducts()
          .then((response) => {
            console.log(response);
            this.setState(response.data);
          })
          .catch((e) => {
            console.log(e);
          });
  }

  render() {
    return (

      <Card>
        <CardContent>
          <Typography color="textSecondary" gutterBottom>
            Products
        </Typography>
          <Divider />
          <Table>
            <TableHead>
              <TableRow> 
                <TableCell></TableCell>
                <TableCell>Name</TableCell>
                <TableCell>Supplier</TableCell>
                <TableCell>Rate</TableCell>
                <TableCell>Contract Length</TableCell>
                <TableCell>Renewable</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {
                this.state.products.map((product) => {
                  return (
                    <TableRow key={product.id}>
                        <TableCell><a className="text-dark" href={`/products/${product.id}`}>Show</a></TableCell>
                        <TableCell>{product.name}</TableCell>
                        <TableCell>{product.supplier}</TableCell>
                        <TableCell>{product.rate}</TableCell>
                        <TableCell>{product.contractLength}</TableCell>
                        <TableCell>{product.renewable}</TableCell>
                    </TableRow>
                  )
                })
              }
            </TableBody>
          </Table>
        </CardContent>
      </Card>

    );
  }
}

export default AllProducts;
