const API_BASE_URL = 'http://localhost:5125/api';

const getToken = () => {
  return localStorage.getItem('token');
};

const redirectToLogin = () => {
  window.location.href = '/login';
};

const fetchData = async (url: string) => {
  const token = getToken();
  if (!token) {
    redirectToLogin();
    throw new Error('Token de autenticação não encontrado!');
  }

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method: 'GET',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
  });

  if (!response.ok) {
    if (response.status === 401) {
      redirectToLogin();
    }
    throw new Error('Erro ao buscar dados');
  }

  return await response.json();
};

const deleteData = async (url: string) => {
  const token = getToken();
  if (!token) {
    redirectToLogin();
    throw new Error('Token de autenticação não encontrado!');
  }

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method: 'DELETE',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
  });

  if (!response.ok) {
    if (response.status === 401) {
      redirectToLogin(); 
    }
    throw new Error('Erro ao deletar');
  }

  return await response;
};

const postData = async (url: string, data: any) => {
  const token = getToken();
  if (!token) {
    redirectToLogin();
    throw new Error('Token de autenticação não encontrado!');
  }

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method: 'POST',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  });

  if (!response.ok) {
    if (response.status === 401) {
      redirectToLogin();
    }
    throw new Error('Erro ao criar dados');
  }

  return await response.json();
};

const putData = async (url: string, data: any) => {
  const token = getToken();
  if (!token) {
    redirectToLogin();
    throw new Error('Token de autenticação não encontrado!');
  }

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method: 'PUT',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  });

  if (!response.ok) {
    if (response.status === 401) {
      redirectToLogin();
    }
    throw new Error('Erro ao atualizar dados');
  }

  return await response;
};

export { fetchData, deleteData, postData, putData };