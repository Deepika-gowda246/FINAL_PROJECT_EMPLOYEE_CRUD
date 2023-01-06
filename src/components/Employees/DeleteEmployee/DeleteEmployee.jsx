import React from "react";
import axios from "axios";
import { useState, useEffect } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import swal from 'sweetalert';  


let ViewEmployee = () => {

    let {employeeId} = useParams();
    const navigate = useNavigate();

    const[employee, setEmployees] = useState([])

    useEffect(() => {
        axios.get(`https://localhost:44313/api/Employees/${employeeId}`).then((response) => {
            setEmployees((existingData) => {
                return response.data;
            })
        })
    }, []);

    function deleteEmployeeHandler(){
       
        axios.delete(`https://localhost:44313/api/Employees/${employeeId}` )
        .then((response) => {
            navigate("/employees/list");
            swal({
                title: "Employee Deleted Successfully!",
                icon: "error",
                button: "OK",
              });
        })


    }

    return(
        <React.Fragment>
            <section className="view-employee-intro p-3">
                <div className="comtainer">
                    <div className="row">
                        <div className="col">
                            <h1 className="h3  fw-bold " style={{color:'pink', fontSize:40,padding:10,fontFamily:'sans-serif', marginLeft:380}}>Hey Are your Sure, You want to delete..?</h1>
                        </div>
                    </div>
                </div>

            </section>

            {
                Object.keys(employee).length > 0 &&
                <section className="view-employee mt-3">
                <div className="container"
                style={{ backgroundColor: '#000',
                color: 'white',
                width:835,
                fontSize:18,
                borderBlockColor:'white',
                }}>
                    <div className="row align-items-center">
                        <div className="col-md-4">
                            <img src={employee.imageUrl} className="employee-img"/>

                        </div>
                        <div className="col-md-8">
                        <ul className="list-group" style={{width:600,marginLeft:0}}>
                                            <li className="list-group-item list-group-item-action">
                                                    Name : <span className="fw-bold">{employee.employeeName}</span>
                                            </li>
                                            <li className="list-group-item list-group-item-action">
                                                    Band : <span className="fw-bold">{employee.band}</span>
                                            </li>
                                            <li className="list-group-item list-group-item-action">
                                                    Designation : <span className="fw-bold">{employee.designation}</span>
                                            </li>
                                            <li className="list-group-item list-group-item-action">
                                                    Role : <span className="fw-bold">{employee.role}</span>
                                            </li>
                                            <li className="list-group-item list-group-item-action">
                                                    Responsibility : <span className="fw-bold">{employee.responsibilities}</span>
                                            </li>
                                        </ul>
                        </div>
                    </div>
                    <div className="row mt-2" style={{marginLeft:268}}>
                        <div className="col">
                        <Link to={'/employees/list'} type="submit" className="btn btn-danger"  style={{width:100,paddingLeft:5}} placeholder="Yes" value="Yes" onClick={deleteEmployeeHandler}>Yes</Link>

                            <Link to={'/employees/list'} className="btn btn-success" style={{width:100,marginLeft:5}}>No</Link>
                        </div>
                    </div>
                </div>
            </section>
            }
        </React.Fragment>
    )
};

export default ViewEmployee;