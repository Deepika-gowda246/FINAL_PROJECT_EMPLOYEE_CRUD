import React, { useEffect, useState } from "react";
import { Link, Route, useNavigate, useParams } from "react-router-dom";
import { useRef } from "react";
import axios from "axios";
import swal from 'sweetalert';  
let EditEmployee = () => {
    const empName = useRef("");
    const band=useRef("");
    const role=useRef("");
    const designation=useRef("");
    const resp=useRef("");
    const url=useRef("");

    const{employeeId} = useParams();

    const navigate = useNavigate();


    useEffect(() => {
        
        axios.get(`https://localhost:44313/api/Employees/${employeeId}`)
        .then((response) =>{
            empName.current.value=response.data.employeeName;
            band.current.value=response.data.band;
            role.current.value=response.data.role;
            designation.current.value=response.data.designation;
            resp.current.value=response.data.responsibilities;
            url.current.value=response.data.imageUrl;



        });
    },[]);

    function updateEmployeeHandler(){
        var payload = {
            "employeeId": employeeId,
            "employeeName": empName.current.value,
            "band": band.current.value,
            "role": role.current.value,
            "designation": designation.current.value,
            "responsibilities":  resp.current.value,
            "imageUrl": url.current.value

           
           
        }
        if(empName.current.value!="" && 
        band.current.value!="" && 
        role.current.value!=""&& 
        designation.current.value!=""&& 
        resp.current.value!=""&& 
        url.current.value!=""){
        axios.put(`https://localhost:44313/api/Employees/${employeeId}` , payload)
        .then((response) => {
            navigate("/employees/list");
            swal({
                title: "Employee Updated Successfully !",
                icon: "success",
                button: "OK",
              });
        })
    }

    }


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
            <section className="add-employee p-3">
                <div className="container">
                    <div className="row">
                        <div className="col">
                            <p className="h3  fw-bold" style={{color:'pink', fontSize:40,padding:10,fontFamily:'sans-serif'}}>
                                Update Employee
                            </p>
                        </div>
                    </div>
                    <div className="row" >
                        <div className="col-md-4">
                            <form
                            style={{ 
                                color: 'black',
                                width:435,
                                fontSize:18,
                                borderBlockColor:'white',
                                opacity: 0.8}}>
                                <div className="mb-2">
                                    <input
                                    required={true}
                                     type="text" className="form-control" placeholder="Name" ref={empName}/>
                                </div>
                                <div className="mb-2">
                                    <input type="text" className="form-control" placeholder="Band" ref={band}/>
                                </div>
                                <div className="mb-2">
                                    <input type="text" className="form-control" placeholder="Role" ref={role}/>
                                </div>
                                <div className="mb-2">
                                    <input type="text" className="form-control" placeholder="Desingnation" ref={designation}/>
                                </div>
                                <div className="mb-2">
                                    <input type="text" className="form-control" placeholder="Responsibilites" ref={resp}/>
                                </div>
                                <div className="mb-2">
                                    <input type="text" className="form-control" placeholder="Photo Url" ref={url}/>
                                </div>
                                <div className="mb-2">
                                    <Link to={'/employees/list'}  type="submit" className="btn btn-success" placeholder="Create" onClick={updateEmployeeHandler}>Update</Link>
                                    <Link to={'/employees/list'} className="btn btn-warning ms-2" >Cancel</Link>
                                </div>
                               
                            </form>
                        </div>
                        
                    <div className="col-md-6">
                        <img src={employee.imageUrl} className="employee-img" />
                    </div>
                        
                    </div>
                </div>
            </section>
        </React.Fragment>
    )
};

export default EditEmployee;



