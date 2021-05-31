import React, { Component, useEffect, useState } from 'react';
import Kamera1Img from '../../img/1.jpg';
import { get, post, postImage } from '../requests/Request';
import * as urlConfig from '../requests/urlconfigs';
const Kamera1 = () => {
    const [guncelKamera, setGuncelKamera] = useState({
        isLoading: true,
        data: {"kameraId":null}
    });

    useEffect(() => {
        KameraGuncelle();
    })

    const KameraGuncelle = () => {
        let search = window.location.search;
        let params = new URLSearchParams(search);
        let kameraId = params.get('kameraId');
        guncelKamera.isLoading = false;
        guncelKamera.data.kameraId = kameraId;
        if (kameraId) {
            post(urlConfig.SERVICE_URL + "/api/yonetim/kameraguncelle", guncelKamera.data)
                .then(response => response.json())
                .then(data => {
                    if (data.success) {

                    }
                    else {
                    }
                });
        }
    }

    return (
        <div className="container content">
            <img src={Kamera1Img} className="img-fluid"></img>
        </div>
    )
}

export default Kamera1;
