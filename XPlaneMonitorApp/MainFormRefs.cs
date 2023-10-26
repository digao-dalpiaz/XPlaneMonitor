﻿using XPlaneMonitorApp.Communicator;
using XPlaneMonitorApp.Functions;

namespace XPlaneMonitorApp
{
    public partial class MainForm
    {

        private RefDataContractList GetRefDataContractList()
        {
            RefDataContractList lst = new();

            lst.Subscribe("sim/flightmodel/position/indicated_airspeed", r =>
            {
                lbAirSpeed.Value = Utils.RoundToInt(r.Value) + " kts";
            });
            lst.Subscribe("sim/flightmodel/position/vh_ind_fpm", r =>
            {
                int v = Utils.RoundToInt(r.Value); //round before check value to avoid different value from view!!!
                lbVerticalSpeed.Value = v + " ft/min";
                lbVerticalSpeed.ForeColor = v >= 0 ? Color.Green : Color.Red;
                icoVerticalSpeed.Image = v >= 0 ? Properties.Resources.arrow_up : Properties.Resources.arrow_down;
                icoVerticalSpeed.Visible = v != 0;
            });
            lst.Subscribe("sim/flightmodel/position/groundspeed", r =>
            {
                //original value in m/s
                lbGroundSpeed.Value = Utils.RoundToInt(r.Value * 3.6) + " km/h";
            });
            lst.Subscribe("sim/flightmodel/misc/h_ind", r =>
            {
                lbAltitude.Value = Utils.RoundToInt(r.Value) + " ft";
            });
            lst.Subscribe("sim/flightmodel2/position/pressure_altitude", r =>
            {
                _altitudeTrue = r.Value;
                lbAltitudeTrue.Value = Utils.RoundToInt(r.Value) + " ft";
            });
            lst.Subscribe("sim/cockpit2/gauges/indicators/radio_altimeter_height_ft_pilot", r =>
            {
                lbRadioAltimeter.Value = Utils.RoundToInt(r.Value) + " ft";
            });
            lst.Subscribe("sim/cockpit2/gauges/indicators/compass_heading_deg_mag", r =>
            {
                lbHeading.Value = Utils.RoundToInt(r.Value) + "º";
            });
            lst.Subscribe("sim/flightmodel2/position/true_psi", r =>
            {
                _headingTrue = r.Value;
                _aircraftMarker.Angle = r.Value;
                lbHeadingTrue.Value = Utils.RoundToInt(r.Value) + "º";
            });

            lst.Subscribe("sim/cockpit2/switches/auto_brake_level", r =>
            {
                lbAutoBrake.Value = r.Value == 0 ? "RTO" : r.Value == 1 ? "OFF" : "ON " + (r.Value-1);
            });
            lst.Subscribe("sim/flightmodel/controls/parkbrake", r =>
            {
                bool on = r.Value == 1;

                lbParkingBrake.Value = on ? "SET" : "RELEASED";
                lbParkingBrake.ForeColor = on ? Color.Red : Color.Green;

                icoParkingBrake.Visible = on;
            });

            lst.Subscribe("sim/cockpit2/gauges/indicators/wind_speed_kts", r =>
            {
                lbWindSpeed.Value = Utils.RoundToInt(r.Value) + " kts";
            });
            lst.Subscribe("sim/cockpit2/gauges/indicators/wind_heading_deg_mag", r =>
            {
                lbWindHeading.Value = Utils.RoundToInt(r.Value) + "º";
            });

            lst.Subscribe("sim/cockpit2/temperature/outside_air_temp_deg" + (Vars.Cfg.DegreesUnit == Config.DegreesUnitType.CELSIUS ? "c" : "f"), r =>
            {
                lbOutsideTemp.Value = Utils.RoundToInt(r.Value) + "º" + (Vars.Cfg.DegreesUnit == Config.DegreesUnitType.CELSIUS ? "C" : "F");
            });

            lst.Subscribe("sim/cockpit/autopilot/autopilot_mode", r =>
            {
                //off=0, flight director=1, on=2
                lbAutoPilot.Value = r.Value == 0 ? "OFF" : r.Value == 1 ? "FLIGTH DIR" : r.Value == 2 ? "ON" : "?";
            });
            lst.Subscribe("sim/cockpit2/autopilot/autothrottle_enabled", r =>
            {
                //-1=hard off, not even armed. 0=servos declutched (arm, hold), 1=airspeed hold, 2=N1 target hold, 3=retard, 4=reserved for future use
                lbAutoThrottle.Value = r.Value == -1 ? "OFF" : r.Value == 0 ? "ARMED" : r.Value == 1 ? "SPEED HOLD" : r.Value == 2 ? "N1 TGT HOLD" : r.Value == 3 ? "RETARD" : "?";
            });

            lst.Subscribe("sim/flightmodel/controls/flaprqst", r =>
            {
                gaugeFlaps.Bars[0].Pos = r.Value;
                gaugeFlaps.Reload();
            });
            lst.Subscribe("sim/cockpit2/controls/flap_system_deploy_ratio", r =>
            {
                gaugeFlaps.Bars[1].Pos = r.Value;
                gaugeFlaps.Reload();
            });

            lst.Subscribe("sim/cockpit2/switches/dump_fuel", r =>
            {
                gaugeFuel.GaugeTitle = "Fuel" + (r.Value == 1 ? " - DUMPING!!!" : "");
            });
            lst.Subscribe("sim/aircraft/weight/acf_m_fuel_tot", r =>
            {
                _fuelTotalCapacity = r.Value;
                //keep before another subscribe where this var is used
            });
            lst.Subscribe("sim/aircraft/overflow/acf_num_tanks", r =>
            {
                gaugeFuel.ShowBarsCount = (int)r.Value;
                gaugeFuel.Reload();
            });
            lst.Subscribe("sim/aircraft/overflow/acf_tank_rat", r =>
            {
                gaugeFuel.Bars[r.ArrayIndex].Max = r.Value * _fuelTotalCapacity;
                gaugeFuel.Reload();
            }, 4);
            lst.Subscribe("sim/cockpit2/fuel/fuel_quantity", r =>
            {
                gaugeFuel.Bars[r.ArrayIndex].Pos = r.Value;
                gaugeFuel.Reload();
            }, 4);

            lst.Subscribe("sim/cockpit/switches/gear_handle_status", r =>
            {
                var bar = gaugeGear.Bars[0];
                bar.Pos = r.Value;
                bar.Extra = r.Value == -1 ? "UP/OFF" : r.Value == 0 ? "UP/PREPARED" : r.Value == 1 ? "DOWN" : "?";
                gaugeGear.Reload();
            });
            lst.Subscribe("sim/flightmodel/movingparts/gear1def", r =>
            {
                gaugeGear.Bars[1].Pos = r.Value;
                gaugeGear.Reload();
            });

            lst.Subscribe("sim/cockpit2/controls/left_brake_ratio", r =>
            {
                gaugeWheelBrake.Bars[0].Pos = r.Value;
                gaugeWheelBrake.Reload();
            });
            lst.Subscribe("sim/cockpit2/controls/right_brake_ratio", r =>
            {
                gaugeWheelBrake.Bars[1].Pos = r.Value;
                gaugeWheelBrake.Reload();
            });

            lst.Subscribe("sim/cockpit/engine/APU_switch", r =>
            {
                //0 = off, 1 = on, 2 = start
                var bar = gaugeAPU.Bars[0];
                bar.Pos = r.Value;
                bar.Extra = r.Value == 0 ? "OFF" : r.Value == 1 ? "ON" : r.Value == 2 ? "START" : "?";
                gaugeAPU.Reload();
            });
            lst.Subscribe("sim/cockpit/engine/APU_N1", r =>
            {
                gaugeAPU.Bars[1].Pos = r.Value;
                gaugeAPU.Reload();
            });

            lst.Subscribe("sim/flightmodel/controls/lsplrdef", r =>
            {
                gaugeSpoilers.Bars[0].Pos = r.Value;
                gaugeSpoilers.Reload();
            });
            lst.Subscribe("sim/flightmodel/controls/rsplrdef", r =>
            {
                gaugeSpoilers.Bars[1].Pos = r.Value;
                gaugeSpoilers.Reload();
            });

            lst.Subscribe("sim/flightmodel/controls/sbrkrqst", r =>
            {
                var bar = gaugeSpeedBrake.Bars[0];
                bar.Pos = r.Value;
                bar.Extra = r.Value < 0 ? "ARMED" : null;
                gaugeSpeedBrake.Reload();
            });
            lst.Subscribe("sim/flightmodel/controls/sbrkrat", r =>
            {
                gaugeSpeedBrake.Bars[1].Pos = r.Value;
                gaugeSpeedBrake.Reload();
            });

            lst.Subscribe("sim/cockpit2/controls/elevator_trim", r =>
            {
                gaugeElvTrim.Bars[0].Pos = r.Value + 1;
                gaugeElvTrim.Reload();
            });

            //--Engines
            lst.Subscribe("sim/aircraft/engine/acf_num_engines", r =>
            {
                gaugeThrottle.ShowBarsCount = (int)r.Value * 3;
                gaugeThrottle.Reload();
            });

            void updEngine(RefDataSubscription r, int barIndex)
            {
                gaugeThrottle.Bars[(r.ArrayIndex * 3) + barIndex].Pos = r.Value;
                gaugeThrottle.Reload();
            }

            lst.Subscribe("sim/cockpit2/engine/actuators/throttle_ratio", r => updEngine(r, 0), 4);
            lst.Subscribe("sim/cockpit2/engine/indicators/N1_percent", r => updEngine(r, 1), 4);
            lst.Subscribe("sim/cockpit2/engine/indicators/N2_percent", r => updEngine(r, 2), 4);

            lst.Subscribe("sim/flightmodel/engine/ENGN_propmode", r =>
            {
                //feather=0,normal=1,beta=2,reverse=3
                gaugeThrottle.Bars[3 * r.ArrayIndex].Extra = r.Value == 3 ? "REVERSE" : "";
                gaugeThrottle.Reload();
            }, 4);
            //--

            lst.Subscribe("sim/flightmodel/controls/dist", r =>
            {
                lbFlightDist.Value = Utils.RoundToInt(r.Value) + " m";
            });

            lst.Subscribe("sim/time/total_flight_time_sec", r =>
            {
                var time = TimeSpan.FromSeconds(r.Value);
                var hours = time.TotalHours;
                var hoursInt = Math.Floor(hours);
                var min = (hours - hoursInt) * 60;
                var minInt = Math.Floor(min);
                var sec = (min - minInt) * 60;
                var secInt = Math.Floor(sec);
                stSimTime.Text = "Simulator time elapsed: " +  hoursInt + ":" + minInt.ToString("00") + ":" + secInt.ToString("00");
            });

            //

            //### LATITUDE AND LONGITUDE MUST BE ALWAYS THE LAST PARAMETER TO RECEIVE, BECAUSE UPDATE METHOS DEPENDS ON OTHERS PARAMETERS

            lst.Subscribe("sim/flightmodel/position/latitude", r =>
            {
                _tmpReceivedLatitude = r.Value; //assuming latitude always received before longitude (I hope!)
            });
            lst.Subscribe("sim/flightmodel/position/longitude", r =>
            {
                _lat = _tmpReceivedLatitude;
                _lng = r.Value;
                ReceivedAircraftPosition(); //here there is update approach params, that depends on others parameter just received before
            });

            return lst;
        }

    }
}