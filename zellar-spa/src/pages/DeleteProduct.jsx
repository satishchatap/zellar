import React, { } from "react";
import productsService from "../store/productsService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import { grey } from "@material-ui/core/colors";


class DeleteProduct extends React.Component {

  static displayName = DeleteProduct.name;

  constructor(props) {
    super(props);
    this.state = {
      id: this.props.match.params.id,
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveDeleteProduct = this.saveDeleteProduct.bind(this);
    this.newDeleteProduct = this.newDeleteProduct.bind(this);
  }

  handleInputChange = event => {
    const { name, value } = event.target;
    this.setState(
      () => {
        return {
          [name]: value
        };
      })
  };

  saveDeleteProduct = () => {
        productsService
          .deleteProduct(this.state.id)
          .then(response => {
            this.setState({
              id: response.data.id,
              submitted: true
            });
          })
          .catch(e => {
            console.log(e);
          });
  };

    newDeleteProduct = () => {
        this.props.history.push('/allproducts');
  };

  render() {

    const styles = {
      toggleDiv: {
        marginTop: 20,
        marginBottom: 5
      },
      toggleLabel: {
        color: grey[400],
        fontWeight: 100
      },
      buttons: {
        marginTop: 30,
        float: "right"
      },
      saveButton: {
        marginLeft: 5
      }
    };

    return (

      <PageBase title="Delete Product" navigation="My Products / Delete Product">

        {this.state.submitted ? (
          <div>
            <div style={styles.buttons}>
              <Button
                style={styles.saveButton}
                variant="contained"
                type="submit"
                color="primary"
                onClick={this.newDeleteProduct}
              >
                Another one
                  </Button>
            </div>
          </div>
        ) : (
            <div style={styles.buttons}>
              <Link to="/">
                <Button variant="contained">Cancel</Button>
              </Link>

              <Button
                style={styles.saveButton}
                variant="contained"
                type="submit"
                color="primary"
                onClick={this.saveDeleteProduct}
              >
                Save
                      </Button>
            </div>
          )}

      </PageBase>
    );
  }
}

export default withRouter(DeleteProduct);
