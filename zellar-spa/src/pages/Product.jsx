import React, { } from "react";
import productsService from "../store/productsService";
import { withRouter } from "react-router";
import { Typography } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import { Link } from 'react-router-dom';
import { grey } from "@material-ui/core/colors";
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import { makeStyles } from '@material-ui/core/styles';
import TextField from "@material-ui/core/TextField";
import InputLabel from '@material-ui/core/InputLabel';
const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        overflow: 'hidden',
        padding: theme.spacing(0, 3),
    },
    paper: {
        maxWidth: 400,
        margin: `${theme.spacing(1)}px auto`,
        padding: theme.spacing(2),
    },
}));

class Product extends React.Component {

    static displayName = Product.name;

    constructor(props) {
        super(props);

        this.state = {
            error: false,
            message: "",
            estimatedConsumption:null,
            estimatedCost:null,
            Id: this.props.match.params.id,
            product: {
            }
        }
        this.fetchData(this.state.Id);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleInputChange = event => {
        const { name, value } = event.target;
        this.setState(
            () => {
                return {
                    [name]: value
                };
            })
        if (name === 'estimatedConsumption') {
            this.setState(
                () => {
                    return {
                        ['estimatedCost']: ((this.state.product.dailyStandingCharge * 365) + (value * this.state.product.rate)) * (this.state.product.contractLength / 12) 
                    };
                })
        }
    };
    fetchData = id => {
        productsService
            .getProduct(id)
            .then((response) => {
                this.setState(response.data);
                console.log(response.data);
            })
            .catch((e) => {
                console.log(e);
            });
    };

    componentDidMount() {

    }

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

            <React.Fragment>
                <div className={useStyles.root}>
                    <Paper className={useStyles.paper}>
                        <Grid container spacing={2}>
                            <Grid item xs={12} sm container>
                                <Grid item xs container direction="column" spacing={2}>
                                    <Grid item xs>
                                        <Typography gutterBottom variant="subtitle1">
                                            Name : {this.state.product.name}
                                        </Typography>
                                        <Typography variant="body2" gutterBottom>
                                            Supplier : {this.state.product.supplier}
                                        </Typography>
                                        <Typography variant="body2" gutterBottom>
                                            Rate : {this.state.product.rate}
                                        </Typography>
                                        <Typography variant="body2" gutterBottom>
                                            Contract Length : {this.state.product.contractLength}
                                        </Typography>
                                        <Typography variant="body2" gutterBottom>
                                            Renewable : {this.state.product.renewable}
                                        </Typography>
                                        <Typography variant="body2" gutterBottom>
                                            Status : {this.state.product.status}
                                        </Typography>
                                        <Typography variant="body2" color="textSecondary">
                                            Id : {this.state.product.id}
                                        </Typography>
                                    </Grid>
                                </Grid>
                            </Grid>
                        </Grid>

                        <Grid item>
                            <TextField
                                hintText="Estimated Consumption"
                                label="Estimated Consumption"
                                fullWidth={true}
                                margin="normal"
                                value={this.state.estimatedConsumption}
                                onChange={this.handleInputChange}
                                name="estimatedConsumption"
                                id="estimatedConsumption"
                                required
                            />
                            <InputLabel name="estimatedCost" id="cost-label" >&pound; {this.state.estimatedCost}</InputLabel>
                        </Grid>
                        <div style={styles.buttons}>


                            <Button component={Link} to={`/CreateProduct/${this.state.Id}`} variant="contained" color="primary">
                                Edit
                            </Button>

                            <Button component={Link} to={`/products/${this.state.Id}/Delete`} variant="contained" color="secondary">
                                Delete
                            </Button>

                        </div>

                    </Paper>
                </div>
            </React.Fragment>
        );
    }
}

export default withRouter(Product);
