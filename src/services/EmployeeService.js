import axios from 'axios';



export class EmployeeService{
    // static serverURL=`http://localhost:9000`;
    static serverURL=`https://localhost:7134/api`;

    

    static getAllEmployees(){
        let dataURL = `${this.serverURL}/Employees`;
        return axios.get(dataURL);
    }


}