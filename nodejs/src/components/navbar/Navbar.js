import React, { Component, useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import { get, post, postImage } from '../requests/Request';
import * as urlConfig from '../requests/urlconfigs';

const Navbar = () => {
    const [kamera, setKamera] = useState({
        isLoading: true,
        data: []
    })

    const KameralariGetir = () => {
        var request = get(urlConfig.SERVICE_URL + "/api/yonetim/kameralari-getir");
        request.then(data => {
            if (data.success) {
                const formattedMessages = data.data.map((option) => {
                    return {
                        isim: option.isim,
                        kameraId: option.kameraId
                    };
                });
                console.log(formattedMessages);
                setKamera({
                    isLoading: false,
                    data: formattedMessages
                });
            }
        });
    }
    useEffect(() => {
        KameralariGetir();
    }, kamera)

    return (
        <div className="container-fluid">
            <nav className="navbar bg-light navbar-light navbar-expand-sm justify-content-center fixed-top p-3">
                <a href="#" className="navbar-brand">Gölgen</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul className="navbar-nav ">
                        <li className="nav-item ">
                            <div className="dropdown ">
                                <button className="btn btn-ligtht dropdown-toggle" type="button" id="dropdownMenuButton"
                                    data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Kameralar
                        </button>
                                {kamera.isLoading && <p>Kameralar çekiliyor...</p>}
                                {!kamera.isLoading && (
                                    <div className="dropdown-menu clearfix " aria-labelledby="dropdownMenuButton">
                                        {kamera.data.map(kamera=>(
                                            <Link className="dropdown-item" to={"/kamera?kameraId="+kamera.kameraId}>{kamera.isim}</Link>
                                        ))}
                                    </div>

                                )}
                            </div>
                        </li>
                        <li className="nav-item ">
                            <Link className="navlink btn btn-light" to="/rapor">Rapor</Link>

                        </li>
                        <li className="nav-item ">
                            <Link className="navlink btn btn-light" to="/ziyaretcikaydet">Ziyaretçi Kaydet</Link>

                        </li>
                        <li className="nav-item ">
                            <Link className="navlink btn btn-light" to="/gorevlikaydet">Çalışan Kaydet</Link>

                        </li>
                        <li className="nav-item ">
                            <Link className="navlink btn btn-light" to="/kameraekle">Kamera Ekle</Link>

                        </li>

                    </ul>
                </div>
            </nav>

        </div>
    )

}

export default Navbar;