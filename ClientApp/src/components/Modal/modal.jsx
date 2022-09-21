import React, { Component } from "react";
import Multiselect from "multiselect-react-dropdown";
import "./Modal.css";
class Model extends Component {
  constructor() {
    super();
    this.state = {
      model: false,
      selectedValue: [],
      description: "",
    };
    this.toggleModal = this.toggleModal.bind(this);
    this.onChangeList = this.onChangeList.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
    this.checkDisable = this.checkDisable.bind(this);
    this.AddJob = this.AddJob.bind(this);
  }

  onSubmit() {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ Description: this.state.description }),
    };
    fetch("https://localhost:7182/api/jobs/add", requestOptions)
      .then((response) => response.json())
      .then((data) => {
        setTimeout(() => {
          this.AddJob(data.id);
        }, 5000);
      });
  }
  AddJob(jobId) {
    const requestOptions = {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        EmployeesId: this.state.selectedValue.map((e) => e.id),
        jobId: jobId,
      }),
    };
    fetch("https://localhost:7182/api/employees/update", requestOptions)
      .then((response) => response.json())
      .then((data) => {
        alert("All Task Is Done!!");
      });
  }
  checkDisable = () => {
    if (this.state.description === "" && this.state.selectedValue === []) {
      return true;
    }
    return false;
  };
  toggleModal = () => {
    this.setState({
      model: !this.state.model,
      selectedValue: [],
      description: "",
    });
  };
  onChangeList = (newList) => {
    this.setState({ selectedValue: newList });
  };
  handleChange(event) {
    this.setState({ description: event.target.value });
  }
  render() {
    if (this.state.model) {
      document.body.classList.add("active-modal");
    } else {
      document.body.classList.remove("active-modal");
    }
    return (
      <div>
        <button onClick={this.toggleModal} className="btn-modal">
          Assign Job
        </button>

        {this.state.model && (
          <div className="modal">
            <div onClick={this.toggleModal} className="overlay"></div>
            <div className="modal-content">
              <h2>Assign Modal</h2>
              <p>Please choice your employee and assign job to them</p>
              <Multiselect
                options={this.props.data} // Options to display in the dropdown
                selectedValues={this.state.selectedValue} // Preselected value to persist in dropdown
                onSelect={(e) => {
                  this.onChangeList(e);
                }} // Function will trigger on select event
                onRemove={this.onRemove} // Function will trigger on remove event
                displayValue="fullName" // Property name to display in the dropdown options
              />
              <label>
                Job Description.:
                <input
                  className="form-control"
                  type="text"
                  value={this.state.description}
                  onChange={this.handleChange}
                />
              </label>
              <button
                onClick={this.onSubmit}
                className="btn-modal"
                disabled={this.state.description === "" ? true : false}
              >
                Assign
              </button>
              <button className="btn-modal" onClick={this.toggleModal}>
                CLOSE
              </button>
            </div>
          </div>
        )}
      </div>
    );
  }
}

export default Model;
