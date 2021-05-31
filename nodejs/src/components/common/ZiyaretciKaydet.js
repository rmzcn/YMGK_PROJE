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
const ZiyaretciKaydet = () => {
    const useStyles = makeStyles((theme) => ({
        root: {
            '& > *': {
                margin: theme.spacing(1),

            },
        },
    }));
    const classes = useStyles();
    const [data, setData] = useState({});
    const [optionData, setOptionData] = useState({
        isLoading: true,
        data: []
    });
    const [tableData, setTableData] = useState({
        isLoading: true,
        data: []
    });
    const [img, setImg] = useState(null);
    const [fileName, setFileName] = useState(null);
    const onChange = (event) => {
        let e = event.target;
        setData({ ...data, [e.name]: e.value });
    }

    const imgOnChange = (e) => {
        setImg(e.target.files[0]);
        setFileName(e.target.files[0].name);
    }

    const onSave = () => {
        console.log(data);
        if (data) {
            const formData = new FormData();
            formData.append("file", img);
            formData.append("fileName", fileName);
            formData.append("name", data.name);
            formData.append("surname", data.surname);
            formData.append("phoneNumber", data.phoneNumber);
            formData.append("employeeId", data.employeeId);
            formData.append("address", data.address);
            const res = postImage(urlConfig.SERVICE_URL + '/api/yonetim/ziyaretciekle', formData);
            res.then((response) => {
                if (response.data.success) {
                    toast.success(response.data.message)
                    ZiyaretcileriGetir();
                }
                else {
                    toast.error(response.data.message);
                }
            })
        }
    }

    const getOptionData = () => {
        var serverResult = get(urlConfig.SERVICE_URL + '/api/yonetim/getallemployeeoptions');
        serverResult.then(data => {

            if (data.success) {
                setOptionData({
                    isLoading: false,
                    data: data.data
                });
            }

        });
    }

    const ZiyaretcileriGetir=()=>{
        var request = get(urlConfig.SERVICE_URL + "/api/yonetim/ziyaretcileri-getir");
        request.then(data => {
            if (data.success) {
                const formattedMessages = data.data.map((option) => {
                    return {
                        ziyaretciId: option.ziyaretciId,
                        adsoyad: option.adsoyad,
                        telefon: option.telefon,
                        calisanIsmi: option.calisanIsmi,
                        resimUrl: option.resimUrl,
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
        if (optionData.isLoading) {
            getOptionData();
        }
    })

    useEffect(()=>{
        ZiyaretcileriGetir();
    },tableData)


    return (
        <div className="container content">
            <div className="card mx-auto ">
                <div className="card-header text-center">
                    <h5 className="card-title">
                        Yeni Ziyaretçi Kaydet
                            </h5>
                </div>
                <div className="card-body">
                    {optionData.isLoading && <p>Fetching options...</p>}
                    {!optionData.isLoading && (
                        <form className={classes.root} noValidate autoComplete="off">
                            <TextField onChange={onChange} name="name" fullWidth helperText="Ad girin" id="outlined-basic" label="Ad" variant="outlined" />
                            <TextField onChange={onChange} name="surname" fullWidth helperText="Soyad girin" id="outlined-basic" label="Soyad" variant="outlined" />
                            <TextField onChange={onChange} name="phoneNumber" type="number" helperText="Telefon numarası girin" fullWidth id="outlined-basic" label="Telefon Numarası" variant="outlined" />
                            <FormControl fullWidth variant="outlined" className={classes.formControl}>
                                <InputLabel id="demo-simple-select-outlined-label">Gidilecek Çalışanı Seçin</InputLabel>
                                <Select
                                    labelId="demo-simple-select-outlined-label"
                                    id="demo-simple-select-outlined"
                                    label="Age"
                                    name="employeeId"
                                    onChange={onChange}
                                >
                                    {optionData.data.map((option) => (
                                        <MenuItem key={option.key} value={option.key}>{option.value}</MenuItem>
                                    ))}

                                </Select>
                            </FormControl>
                            <FormControl fullWidth>
                                <label>Fotograf</label>
                                <input onChange={imgOnChange} name="file" type="file" accept="image/*" className="form-control"></input>
                            </FormControl>
                            <TextField
                                id="outlined-multiline-static"
                                label="Adres"
                                multiline
                                rows={4}
                                defaultValue="Adres"
                                variant="outlined"
                                fullWidth
                                name="address"
                                onChange={onChange}
                            />

                        </form>
                    )}

                </div>
                <div className="card-footer">
                    <button onClick={onSave} type="button" className="btn btn-primary mx-auto">Kaydet</button>
                </div>
            </div>
            {tableData.isLoading && <p>Ziyaretçiler çekiliyor...</p>}
            {!tableData.isLoading && (
                <div className="mt-4">
                    <TableContainer component={Paper}>
                        <Table className={classes.table} aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell></TableCell>
                                    <TableCell>#</TableCell>
                                    <TableCell align="right">Ad Soyad</TableCell>
                                    <TableCell align="right">Telefon Numarası</TableCell>
                                    <TableCell align="right">Gideceği Çalışan</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {tableData.data.map((data) => (
                                    <TableRow key={data.ziyaretciId}>
                                        <TableCell>
                                            <img className="fluid" width="60px" height="60px" src={urlConfig.SERVICE_URL+data.resimUrl}></img>
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {data.ziyaretciId}
                                        </TableCell>
                                        <TableCell align="right">{data.adsoyad}</TableCell>
                                        <TableCell align="right">{data.telefon}</TableCell>
                                        <TableCell align="right">{data.calisanIsmi}</TableCell>
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

export default ZiyaretciKaydet;