import axios from 'axios';

export function httpGet(url: string, params?: Object): any {
    return axios.get(url, {
        params,
    })
        .then((response) => {
            return Promise.resolve(response.data);
        });
}

export function httpPost(url: string, data: Object): any {
    return axios.post(url, data)
        .then((response) => {
            return Promise.resolve(response.data);
        });
}

export function httpDelete(url: string, entityId: string): any {
    return axios.delete(url, {
        headers: { 'Content-Type': 'application/json' },
        data: JSON.stringify(entityId),
    }).then((response) => {
        return Promise.resolve(response.data);
    });
}

export function httpPostFile(url: string, data: Object, onProgressCheck?: (Function)): any {
    return axios.post(url, data, {
        headers: { 'Content-Type': 'multipart/form-data' },
        onUploadProgress: (progressEvent) => {
            if (onProgressCheck) {
                const progress = Math.round((progressEvent.loaded * 100) / progressEvent.total);
                onProgressCheck(progress);
            }
        },
    }).then((response) => {
        return Promise.resolve(response.data);
    });
}
