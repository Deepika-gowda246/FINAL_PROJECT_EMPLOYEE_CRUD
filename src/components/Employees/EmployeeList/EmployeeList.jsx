import axios from "axios";
import React, {Component, useState} from "react";
import { useEffect } from "react";
import { Link } from "react-router-dom";


let EmployeeList = () => {

   
    


    const[employee1, setEmployees1] = useState([])

    useEffect(() => {
        axios.get("https://localhost:44313/api/Employees").then((response1) => {
            setEmployees1((existingData1) => {
                return response1.data;
            })
        })
    }, []);



    const [searchTerm, setsearchTerm] = useState('')
    
    
    return(
        <React.Fragment>
           

            <section className="employee-search p-4">
                
                <div className="container">
                    <div className="grid">
                        <div className="row">
                            <div className="col">
                                <p className="h3" style={{fontSize:60,color:'pink', fontFamily:'sans-serif',}}><b>Employee Details</b>
                                   
                                </p>
                            </div>
                        </div>
                        



                        <div className="row">
                            <div className="col-md-6">
                                <form className="row pt-4">
                                    <div className="col">
                                        <div className="mb-2">
                                            <input 
                                            name="text"
                                           
                                            style={{ backgroundColor: '#000',
                                                color: 'white',
                                                width:535,
                                                fontSize:18,
                                                borderBlockColor:'white',
                                                opacity: 0.7}}
                                            onChange={Event => {setsearchTerm(Event.target.value)}}
                                            required={true} type="text" className="form-control" placeholder="Search by Designation"/>
                                        </div>
                                    </div>
                                    <div className="col">
                                        <div className="mb-2">
                                            <input type="submit" className="btn btn-outline-light" value="Search" placeholder="Search Employee"/>
                                        </div>
                                    </div>
                                    
                                   
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

            </section>

            <section className="employee-list">
                <div className="container">
                    <div className="row">
                 
                    {

                        
                        
                        employee1.length > 0 &&
                        employee1.filter((emp)=> {
                            if(searchTerm == ""){
                                return emp
                            }else if(emp.designation.toLowerCase().includes(searchTerm.toLowerCase())){
                                return emp
                            }

                           
                           

                            
                        }).map((emp) =>
                        
                          
                        <div className="col-md-6" key={emp.employeeId} >
                            
                            <div className="card my-2" style={{opacity:0.9}} >
                            <div className="card-body" style={{backgroundColor:'#EBBAE2', }}>
                                <div className="row" style={{float:'left',opacity:5.0}} >
                                <div className="col-md-4" >
                                    <img src={emp.imageUrl} className="employee-img"/>
                                </div>
                                <div className="col-md-4" style={{opacity:5.0}}>
                                    <ul className="list-group" style={{width:300,marginLeft:30,marginTop:25}}>
                                        <li className="list-group-item list-group-item-action" style={{height:50}}>
                                                Name : <span className="fw-bold">{emp.employeeName}</span>
                                        </li>
                                        <li className="list-group-item list-group-item-action"  style={{height:50}}>
                                                Band : <span className="fw-bold">{emp.band}</span>
                                        </li>
                                        <li className="list-group-item list-group-item-action"  style={{height:50}}>
                                                Designation : <span className="fw-bold">{emp.designation}</span>
                                        </li>
                                        
                                    </ul>
                                </div>
                                </div>
                                <div className="row">
                                <div className="col-md-1" style={{marginLeft:-25,marginTop:20}} >
                                    <Link to={`/employees/view/${emp.employeeId}`} className="btn btn-warning m-2" >
                                        <i className="fa fa-eye"/>
                                    </Link>
                                    <Link to={`/employees/edit/${emp.employeeId}`} className="btn btn-primary m-2" >
                                        <i className="fa fa-pen"/>
                                    </Link>
                                    <Link to={`/employees/delete/${emp.employeeId}`} className="btn btn-danger m-2" >
                                        <i className="fa fa-trash"/>
                                    </Link>
                                </div>
                                </div>
                            </div>
                        </div>
                          
                            
                        </div>
                          )}

                        
                    </div>


                    
                </div>

            </section>
            <div style={{marginLeft:650, marginTop:30, marginBottom:30}}>
            <Link to={'/employees/add'} className="btn btn-primary ms-2" >
                                    <i class=" fa fa-light fa-user-plus"></i>
                                    &nbsp; Add New Employee</Link>
            </div>
           
        </React.Fragment>
    )
};

export default EmployeeList;