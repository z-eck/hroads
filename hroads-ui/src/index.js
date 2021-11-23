import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Routes as Switch, Redirect } from 'react-router-dom'
import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';

import Home from './pages/home/App';
import Login from './pages/login/login';
import NotFound from './pages/notfound/notfound';
import Admin from './pages/dashadmin/admin';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoUsuario = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && (parseJwt().role === '2'  || parseJwt().role === '3') ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" element={Home} />
        <Route path="/login" element={Login} />
        <Route path="/notfound" element={NotFound} />
        <PermissaoAdm path="/dashadmin" element={Admin} />
        <Redirect to="/notfound" />
      </Switch>
    </div>
  </Router>

)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
