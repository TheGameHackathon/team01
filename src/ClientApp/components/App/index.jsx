import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor () {
        super();
        this.state = {
            score: 0,
            fieldState: {}
        };
    }
    
    componentDidMount() {
        document.addEventListener("keydown", this.handleKeyPress, false);

        fetch(`/api/game/field`)
            .then(res => res.json())
            .then(res => this.onReponse(res));

    }

    componentWillUnmount() {
        document.removeEventListener("keydown", this.handleKeyPress, false);
    }

    handleKeyPress = (e) => {
        switch (e.keyCode) {
            case 37:
                fetch(`/api/game/score`)
                    .then(res => res.json())
                    .then(res => this.onReponse(res) );
        }
        
    }

    onReponse = (fieldState) => {

        console.log(fieldState);
        this.setState({fieldState});
    }

    keyCodes = {
        37: "left",
        38: "up",
        39: "right",
        40: "down"
    }

    render () {
        return (
            <div className={styles.root}>
                <div className={ styles.score }>
                    Ваш счет: { this.state.score }
                </div>
                <Field fieldState={this.state.fieldState} />
            </div>
        );
    }
}
