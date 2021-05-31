import React, { Component, useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';
import { get, post, postImage } from '../requests/Request';
import * as toast from '../utilities/Toast';
import * as urlConfig from '../requests/urlconfigs';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const KameraEkle = () => {
    const useStyles = makeStyles((theme) => ({
        root: {
            '& > *': {
                margin: theme.spacing(1),

            },
        },
        table: {
            minWidth: 650,
        },

    }));
    const classes = useStyles();
    const [data, setData] = useState({});
    const [tableData, setTableData] = useState({
        isLoading: true,
        data: []
    });
    const [optionData, setOptionData] = useState({
        isLoading: true,
        data: []
    });

    const onChange = (event) => {
        let e = event.target;
        setData({ ...data, [e.name]: e.value });
    }

    const onSave = () => {
        post(urlConfig.SERVICE_URL + "/api/yonetim/kamera-ekle", data)
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    toast.success(data.message);
                    KameralariGetir();
                }
                else {
                    toast.error(data.error);
                }
            });
    }

    const KameralariGetir= ()=>{
        var request = get(urlConfig.SERVICE_URL + "/api/yonetim/kameralari-getir");
        request.then(data => {
            if (data.success) {
                const formattedMessages = data.data.map((option) => {
                    return {
                        kullaniciAdi: option.kullaniciAdi,
                        sifre: option.sifre,
                        ip: option.ip,
                        isim: option.isim,
                        protokol: option.protokol,
                        kameraId:option.kameraId
                    };
                });
                console.log(formattedMessages);
                setTableData({
                    isLoading: false,
                    data: formattedMessages
                });
            }
        });
    }

    useEffect(() => {
       KameralariGetir();
    }, tableData)


    return (
        <div className="container content">
            <div className="card mx-auto ">
                <div className="card-header text-center">
                    <h5 className="card-title">
                        Yeni Kamera Kaydet
                            </h5>
                </div>
                <div className="card-body">
                    <form className={classes.root} noValidate autoComplete="off">
                        <TextField onChange={onChange} name="isim" type="text" helperText="Kamera Adı" fullWidth id="outlined-basic" label="Kamera Adı" variant="outlined" />
                        <TextField onChange={onChange} name="kullaniciadi" fullWidth helperText="Kullanıcı adı girin" id="outlined-basic" label="Kullanıcı Adı" variant="outlined" />
                        <TextField type="password" onChange={onChange} name="sifre" fullWidth helperText="Şifre girin" id="outlined-basic" label="Şifre" variant="outlined" />
                        <TextField onChange={onChange} name="ipadresi" type="text" helperText="İp adresi girin" fullWidth id="outlined-basic" label="İp Adresi" variant="outlined" />
                    </form>
                </div>
                <div className="card-footer">
                    <button onClick={onSave} type="button" className="btn btn-primary mx-auto">Kaydet</button>
                </div>
            </div>
            {tableData.isLoading && <p>Kameralar çekiliyor...</p>}
            {!tableData.isLoading && (
                <div className="mt-4">
                    <TableContainer component={Paper}>
                        <Table className={classes.table} aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell>#</TableCell>
                                    <TableCell align="right">Kamera İsmi</TableCell>
                                    <TableCell align="right">İp Adresi</TableCell>
                                    <TableCell align="right">Kullanıcı Adı</TableCell>
                                    <TableCell align="right">Şifre</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {tableData.data.map((data) => (
                                    <TableRow key={data.kameraId}>
                                        <TableCell component="th" scope="row">
                                            {data.kameraId}
                                        </TableCell>
                                        <TableCell align="right">{data.isim}</TableCell>
                                        <TableCell align="right">{data.ip}</TableCell>
                                        <TableCell align="right">{data.kullaniciAdi}</TableCell>
                                        <TableCell align="right">{data.sifre}</TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </div>
            )}
        </div>
    )

}


export default KameraEkle;