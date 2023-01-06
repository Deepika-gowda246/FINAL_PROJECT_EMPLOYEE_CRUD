import React from "react";
import { useState, useEffect } from "react";

let NavBar = () => {

    const[clockState, setClockState] = useState();
    const[clockState1, setClockState1] = useState();
    const[show,setShow]=useState(false);
    const toggler = () => {
        show ? setShow(false) : setShow(true);
    }

    useEffect(()=> {
        setInterval(() => {
            const date = new Date();
            setClockState(date.toLocaleTimeString());
            setClockState1(date.toLocaleTimeString('en-GB'));

        }, 1000);

    },[])

    return(
        <React.Fragment>
            <nav className="navbar navbar-dark bg-dark navbar-expanf-sm">
                <div className="container" style={{float:'left'}}>
                    <a to={'/'} className="navbar-brand" style={{fontSize:35}} ><i class=" fa fa-light fa-wand-magic-sparkles text-warning"></i>&nbsp;&nbsp;Global <span className="text-warning">Logic</span> </a>
                </div>
                <div>
                <select className="btn btn-outline-light" name="cars" id="cars"  style={{color:'red', marginLeft:-150,float:'left'}}>
                    <option value="volvo">{clockState}</option>
                    <option value="saab">{clockState1}</option>
                </select>
                </div>
                
                

            </nav>
        </React.Fragment>
    )
};

export default NavBar;