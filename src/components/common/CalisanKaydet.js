import React, { Component, useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import Input from '@material-ui/core/Input';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';
import { get, post, postImage } from '../requests/Request';
import * as toast from '../utilities/Toast';
import * as urlConfig from '../requests/urlconfigs';
import DropdownMultiselect from "react-multiselect-dropdown-bootstrap";
const CalisanKaydet = () => {
    const useStyles = makeStyles((theme) => ({
        root: {
            '& > *': {
                margin: theme.spacing(1),

            },
        },
    }));
    const classes = useStyles();
    const [data, setData] = useState({});
    const [cameraOptionData, setCameraOptionData] = useState({
        isLoading: true,
        data: null
    });
    const [birimAdiOptions, setBirimAdiOptions] = useState({
        isLoading: true,
        data: null
    });

    const onChange = (event) => {
        
        let e = event.target;
        setData({ ...data, [e.name]: e.value });
        console.log(data);
    }

    const getSelectValue=(e)=>{
        setData({...data,cameraPaths: e})
    }

    useEffect(() => {
        if (cameraOptionData.isLoading) {
            getCameraOptions();
        }
        if (birimAdiOptions.isLoading) {
            getBirimAdiOptions();
        }
    });

    const getCameraOptions = () => {
        var request = get(urlConfig.SERVICE_URL + "/api/yonetim/kameralar");
        request.then(data => {
            if (data.success) {
                const formattedMessages = data.data.map((option) => {
                    return {
                        key: option.key,
                        label: option.value
                    };
                });
                console.log(formattedMessages);
                setCameraOptionData({
                    isLoading: false,
                    data: formattedMessages
                });
            }
        });
    }

    const getBirimAdiOptions = () => {
        var request = get(urlConfig.SERVICE_URL + "/api/yonetim/birimler");
        request.then(data => {
            if (data.success) {
                setBirimAdiOptions({
                    isLoading: false,
                    data: data.data
                });
            }
        });
    }

    const submit=()=>{
        post(urlConfig.SERVICE_URL+"/api/yonetim/calisanekle",data)
        .then(response => response.json())
        .then(data => {
            if(data.success){
                toast.success(data.message);
            }
            else{
                toast.error(data.error);
            }
        });
    }


    return (
        <div className="container content">
            <div className="card mx-auto ">
                <div className="card-header text-center">
                    <h5 className="card-title">
                        Yeni Çalışan Kaydet
                            </h5>
                </div>
                <div className="card-body">
                    {cameraOptionData.isLoading && birimAdiOptions.isLoading && <p>Fetching options...</p>}
                    {!cameraOptionData.isLoading && !birimAdiOptions.isLoading && (
                        <div className={classes.root}>
                            <TextField onChange={onChange} name="ad" fullWidth helperText="Ad girin" id="outlined-basic" label="Ad" variant="outlined" />
                            <TextField onChange={onChange} name="soyad" fullWidth helperText="Soyad girin" id="outlined-basic" label="Soyad" variant="outlined" />
                            <FormControl fullWidth variant="outlined" className={classes.formControl}>
                                <InputLabel id="demo-simple-select-outlined-label">Birim Adını Seçin</InputLabel>
                                <Select
                                    labelId="demo-simple-select-outlined-label"
                                    id="demo-simple-select-outlined"
                                    label="Age"
                                    name="birimId"
                                    onChange={onChange}
                                >
                                    {birimAdiOptions.data.map((option) => (
                                        <MenuItem key={option.key} value={option.key}>{option.value}</MenuItem>
                                    ))}

                                </Select>
                            </FormControl>
                            
                                <DropdownMultiselect
                                    options={cameraOptionData.data}
                                    handleOnChange={getSelectValue}
                                    name="cameraPaths"
                                />
                        </div>
                    )}

                </div>
                <div className="card-footer">
                    <button onClick={submit} type="button" className="btn btn-primary mx-auto">Kaydet</button>
                </div>
            </div>
        </div>
    )
}
export default CalisanKaydet;
