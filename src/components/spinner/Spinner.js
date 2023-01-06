import React from "react";
import spinnerImg from '../../assets/img/spinnervll.gif'

let Spinner = () => {
    return(
        <React.Fragment>
            <img src={spinnerImg} alt="" className="d-block m-auto" />
        </React.Fragment>
    )
};

export default Spinner;