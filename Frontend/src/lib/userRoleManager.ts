
import { browser } from '$app/environment';

const getToken = () => {
    if (browser) {
        return window.localStorage.getItem('token');
    }
    return null;
};


const getUserRole = () => {
    const token = getToken();
    if (token) {
        const decodedToken = JSON.parse(atob(token.split('.')[1])); 
        return decodedToken.role; 
    }
    return null;
};

const isAdmin = () => {
    const role = getUserRole();
    return role === 'Admin';
};

const isModifier = () => {
    const role = getUserRole();
    return role === 'Modifier' || isAdmin();
};

const checkAdminAccess = () => {
    if (!isAdmin()) {
        window.location.href = '/login';
    }
};

const checkModifierAccess = () => {
    if (!isAdmin() && !isModifier()) {
        window.location.href = '/login';
    }
};

export { isAdmin, isModifier, checkAdminAccess, checkModifierAccess };
