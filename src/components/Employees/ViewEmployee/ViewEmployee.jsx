import React from "react";
import axios from "axios";
import { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";

let ViewEmployee = () => {

    let {employeeId} = useParams();

    const[employee, setEmployees] = useState([])

    useEffect(() => {
        axios.get(`https://localhost:44313/api/Employees/${employeeId}`).then((response) => {
            setEmployees((existingData) => {
                return response.data;
            })
        })
    }, []);

    return(
        <React.Fragment>
            <section className="view-employee-intro p-3">
                <div className="container">
                    <div className="row">
                        <div className="col">
                            <p className="h3 text-warning fw-bold " style={{color:'pink', fontSize:40,padding:10,fontFamily:'sans-serif', marginLeft:520}}>View Employee</p>
                        </div>
                    </div>
                </div>

            </section>

            {
                Object.keys(employee).length > 0 &&
                <section className="view-employee mt-3">
                <div className="container"  style={{ backgroundColor: '#000',
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
                            <Link to={'/employees/list'} className="btn btn-warning"><i class="fa-solid fa-backward"></i></Link>
                        </div>
                    </div>
                </div>
            </section>
            }
        </React.Fragment>
    )
};

export default ViewEmployee;