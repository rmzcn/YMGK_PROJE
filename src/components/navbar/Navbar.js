import React, { Component } from 'react'
import {Link} from 'react-router-dom';
export default class Navbar extends Component {
    render() {
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
                                    <div className="dropdown-menu clearfix " aria-labelledby="dropdownMenuButton">
                                        <Link className="dropdown-item" to="/kamera1">Kamera-1</Link>
                                        <Link className="dropdown-item" to="/kamera2">Kamera-2</Link>
                                        <Link className="dropdown-item" to="/kamera3">Kamera-3</Link>
                                        <Link className="dropdown-item" to="/kamera4">Kamera-4</Link>

                                    </div>
                                </div>
                            </li>
                            <li className="nav-item">
                            <Link className="navlink btn btn-light" to="/calisanlar">Çalışanlar</Link>

                            </li>
                            <li className="nav-item ">
                            <Link className="navlink btn btn-light" to="/ziyaretciler">Ziyaretçiler</Link>

                            </li>
                            <li className="nav-item">
                            <Link className="navlink btn btn-light" to="/izleme">İzleme</Link>

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


                        </ul>
                    </div>
                </nav>

            </div>
        )
    }
}
