import React, { Component, useEffect,useState } from 'react'
import * as urlConfig from '../requests/urlconfigs';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { get, post, postImage } from '../requests/Request';
import { makeStyles } from '@material-ui/core/styles';

const Rapor = () => {
    const [tableData, setTableData] = useState({
        isLoading: true,
        data: []
    });
    const useStyles = makeStyles((theme) => ({
        root: {
            '& > *': {
                margin: theme.spacing(1),

            },
        },
    }));
    const classes = useStyles();
    const RaporlariGetir = () => {
        var request = get(urlConfig.SERVICE_URL + "/api/yonetim/raporlar");
        request.then(data => {
            if (data.success) {
                const formattedMessages = data.data.map((option) => {
                    return {
                        raporId: option.raporId,
                        mesaj: option.mesaj
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
        RaporlariGetir();
    }, tableData)



    return (
        <div className="container content">
            {tableData.isLoading && <p>Raporlar çekiliyor...</p>}
            {!tableData.isLoading && (
                <div className="mt-4">
                    <TableContainer component={Paper}>
                        <Table className={classes.table} aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell>#</TableCell>
                                    <TableCell align="right">Mesaj</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {tableData.data.map((data) => (
                                    <TableRow key={data.raporId}>
                                        <TableCell component="th" scope="row">
                                            {data.raporId}
                                        </TableCell>
                                        <TableCell align="right">{data.mesaj}</TableCell>
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

export default Rapor;
