import React, { Component } from 'react';
import Button from '@mui/material/Button';



function ClickButton() {

    return <button>Click</button>;
}
export class Users extends Component {
    static displayName = Users.name;
    constructor(props) {
        super(props);
        this.state = { users: [], loading: true };
    }


    componentDidMount() {
        this.usersData();
    }

   


    static renderForecastsTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Age</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(users =>
                        <tr key={users.id}>
                            <td>{users.id}</td>
                            <td>{users.name}</td>
                            <td>{users.age}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    //отрисовка элемента
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Users.renderForecastsTable(this.state.users);
       

        return (
            <div>
                <h1 id="tabelLabel" >Users</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <ClickButton />
                <p2> {contents}</p2>
                <Button variant="outlined">Outlined</Button>
            </div>
        );
    }

    async usersData() {
        const response = await fetch('user/selectAll');
        const data = await response.json();
        this.setState({ users: data, loading: false });
    }
}