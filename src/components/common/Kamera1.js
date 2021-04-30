import React, { Component } from 'react';
import Kamera1Img from '../../img/1.png';

const Kamera1 =() =>{
    const sleepper=(ms) =>{
        return new Promise(resolve => setTimeout(resolve,ms))
    }

    const image=()=>{
        {sleepper(200)}
        let img=Kamera1Img;
        return(
            <img height="700" src={img} ></img>
        )
    }

        return (
            <div className="container content">
               {image()}
            </div>
        )
}

export default Kamera1;