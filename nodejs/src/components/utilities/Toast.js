import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
toast.configure();

export function success(message){
    return toast.success(message);
}

export function warning(message){
    return toast.warning(message);
} 

export function error(message){
    return toast.error(message);
}

export function info(message){
    return toast.info(message);
}