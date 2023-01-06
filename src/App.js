import React from 'react';
import './App.css';
import {Routes, Route, Navigate} from 'react-router-dom';
import NavBar from './components/Navbar/NavBar';
import AddEmployee from './components/Employees/AddEmployee/AddEmployee';
import ViewEmployee from './components/Employees/ViewEmployee/ViewEmployee';
import EditEmployee from './components/Employees/EditEmployee/EditEmployee';
import EmployeeList from './components/Employees/EmployeeList/EmployeeList';
import DeleteEmployee from './components/Employees/DeleteEmployee/DeleteEmployee';
let App = () => {
  return (
   <React.Fragment>
    <NavBar/>
    <Routes>
      <Route path={'/'} element={<Navigate to={'/employees/list'}/>}/>
      <Route path={'/employees/list'} element={<EmployeeList/>}/>
      <Route path={'/employees/add'} element={<AddEmployee/>}/>
      <Route path={'/employees/view/:employeeId'} element={<ViewEmployee/>}/>
      <Route path={'/employees/edit/:employeeId'} element={<EditEmployee/>}/>
      <Route path={'/employees/delete/:employeeId'} element={<DeleteEmployee/>}></Route>

    </Routes>

   </React.Fragment>
  );
}

export default App;
