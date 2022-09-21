import React, { Component } from "react";
import ReactTable from "react-table-6";
import "react-table-6/react-table.css";
import "./Employee.css";
import Modal from "../Modal/modal";
class GetEmployess extends Component {
  constructor() {
    super();
    this.state = {
      employees: [],
    };
  }

  componentDidMount() {
    const url = "https://localhost:7182/api/employees";
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((employees) => {
        this.setState({ employees });
        console.log(employees);
      });
  }

  render() {
    const columns = [
      {
        Header: "Id",
        accessor: "id",
      },
      {
        Header: "Full Name",
        accessor: "fullName",
      },
      {
        Header: "Phone Number",
        accessor: "phoneNumber",
      },
    ];

    return (
      <div>
        {this.state.employees.length > 0 ? (
          <div>
            <ReactTable
              columns={columns}
              data={this.state.employees}
            ></ReactTable>
            <Modal data={this.state.employees} />
          </div>
        ) : (
          <div>Loading...</div>
        )}
      </div>
    );
  }
}

export default GetEmployess;
