import React, { } from "react";
import productsService from "../store/productsService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import { grey } from "@material-ui/core/colors";
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';

class CreateProduct extends React.Component {

    static displayName = CreateProduct.name;

    constructor(props) {
        super(props);
        this.state = {
            id: null,
            supplier: "",
            name: "",
            rate: "",
            contractLength: "",
            renewable: "",
            dailyStandingCharge: "",
            status: "",
            submitted: false
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.saveProduct = this.saveProduct.bind(this);
        this.newProduct = this.newProduct.bind(this);
        if (this.props.match.params.id !== undefined) {
            this.fetchData(this.props.match.params.id);
        }
    }

    fetchData = id => {
        productsService
            .getProduct(id)
            .then((response) => {
                this.setState(response.data.product);
                console.log(response.data);
            })
            .catch((e) => {
                console.log(e);
            });
    };

    handleInputChange = event => {
        const { name, value } = event.target;
        this.setState(
            () => {
                return {
                    [name]: value
                };
            })
    };

    saveProduct = () => {
        var bodyFormData = new FormData();
        bodyFormData.append('name', this.state.name);
        bodyFormData.append('supplier', this.state.supplier);
        bodyFormData.append('rate', this.state.rate);
        bodyFormData.append('contractLength', this.state.contractLength);
        bodyFormData.append('renewable', this.state.renewable);
        bodyFormData.append('dailyStandingCharge', this.state.dailyStandingCharge);
        bodyFormData.append('status', this.state.status);
        if (this.state.id <= 0) {
            productsService
                .createProduct(bodyFormData)
                .then(response => {
                    this.setState({
                        id: response.data.product.id,
                        name: response.data.product.name,
                        supplier: response.data.product.supplier,
                        rate: response.data.product.rate,
                        contractLength: response.data.product.contractLength,
                        renewable: response.data.product.renewable,
                        dailyStandingCharge: response.data.product.dailyStandingCharge,
                        status: response.data.product.status,
                        submitted: true
                    });
                })
                .catch(e => {
                    console.log(e);
                });
        }
        else {

            productsService
                .editProduct(this.state.id, bodyFormData)
                .then(response => {
                    this.setState({
                        id: response.data.product.id,
                        name: response.data.product.name,
                        supplier: response.data.product.supplier,
                        rate: response.data.product.rate,
                        contractLength: response.data.product.contractLength,
                        renewable: response.data.product.renewable,
                        dailyStandingCharge: response.data.product.dailyStandingCharge,
                        status: response.data.product.status,
                        submitted: true
                    });
                })
                .catch(e => {
                    console.log(e);
                });
        }
    };

    newProduct = () => {
        this.setState({
            id: null,
            name: "",
            supplier: "",
            rate: "",
            contractLength: "",
            renewable: "",
            dailyStandingCharge: "",
            status: "",
            submitted: false
        });
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

            <PageBase title={this.props.match.params.id !== undefined ? "Edit Product" : "Create a New Product"} navigation="My Products / Create a New Product">

                {this.state.submitted ? (
                    <div>
                        <div style={styles.buttons}>
                            <Button
                                style={styles.saveButton}
                                variant="contained"
                                type="submit"
                                color="primary"
                                onClick={this.newProduct}
                            >
                                Another one
                  </Button>
                        </div>
                    </div>
                ) : (
                        <div>

                            <TextField
                                hintText="Name"
                                label="Name"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.name}
                                onChange={this.handleInputChange}
                                name="name"
                                id="name"
                                required
                            />

                            <TextField
                                hintText="Supplier"
                                label="Supplier"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.supplier}
                                onChange={this.handleInputChange}
                                name="supplier"
                                id="supplier"
                                required
                            />

                            <TextField
                                hintText="Contract Length"
                                label="Contract Length"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.contractLength}
                                onChange={this.handleInputChange}
                                name="contractLength"
                                id="contractLength"
                                required
                            />

                            <TextField
                                hintText="Rate"
                                label="Rate"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.rate}
                                onChange={this.handleInputChange}
                                name="rate"
                                id="rate"
                                required
                            />

                            <TextField
                                hintText="Renewable"
                                label="Renewable"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.renewable}
                                onChange={this.handleInputChange}
                                name="renewable"
                                id="renewable"
                                required
                            />

                            <TextField
                                hintText="Daily Standing Charge"
                                label="Daily Standing Charge"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.dailyStandingCharge}
                                onChange={this.handleInputChange}
                                name="dailyStandingCharge"
                                id="dailyStandingCharge"
                                required
                            />
                                <InputLabel id="status-label">Status</InputLabel>
                                <Select
                                    hintText="Status"
                                    label="Status"
                                    fullWidth={true}
                                    labelId="status"
                                    id="status"
                                    name="status"
                                    value={this.state.status}
                                    onChange={this.handleInputChange}
                                >
                                    <MenuItem value={"live"}>Live</MenuItem>
                                    <MenuItem value={"expired"}>Expired</MenuItem>
                                </Select>
                            <div style={styles.buttons}>
                                <Link to="/">
                                    <Button variant="contained">Cancel</Button>
                                </Link>

                                <Button
                                    style={styles.saveButton}
                                    variant="contained"
                                    type="submit"
                                    color="primary"
                                    onClick={this.saveProduct}
                                >
                                    Save
                  </Button>
                            </div>

                        </div>

                    )}
            </PageBase>
        );
    }
}

export default withRouter(CreateProduct);
